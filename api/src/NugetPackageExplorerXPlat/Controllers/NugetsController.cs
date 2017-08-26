using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Packaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NugetPackageExplorerXPlat.Controllers
{
    [Route("api/[controller]")]
    public class NugetsController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            var reader = new PackageArchiveReader("newtonsoft.json.10.0.3.nupkg");

            var packageDeps = reader.GetPackageDependencies();
            var dependencies = packageDeps.ToDictionary(
                pkgDep => pkgDep.TargetFramework.DotNetFrameworkName,
                pkgDep => pkgDep.Packages.Select(pkg => new PackageDto() { Name = $"{pkg.Id} {pkg.VersionRange.PrettyPrint()}" }));

            var metadata = reader.NuspecReader.GetMetadata();
            var extractedMetadata = new
            {
                Id = metadata.FirstOrDefault(meta => meta.Key == "id").Value,
                Version = metadata.FirstOrDefault(meta => meta.Key == "version").Value,
                Title = metadata.FirstOrDefault(meta => meta.Key == "title").Value,
                Author = metadata.FirstOrDefault(meta => meta.Key == "authors").Value,
                Owners = metadata.FirstOrDefault(meta => meta.Key == "owners").Value,
                MinClientVersion = "WIP",
                LicenseUrl = metadata.FirstOrDefault(meta => meta.Key == "licenseUrl").Value,
                ProjectUrl = metadata.FirstOrDefault(meta => meta.Key == "projectUrl").Value,
                Tags = metadata.FirstOrDefault(meta => meta.Key == "tags").Value,
                Copyright = metadata.FirstOrDefault(meta => meta.Key == "copyright").Value,
                Description = metadata.FirstOrDefault(meta => meta.Key == "description").Value,
                Dependencies = dependencies,
            };

            return Json(new
            {
                Metadata = extractedMetadata,

                PackageContents = new { }
            },
            new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented
            });
        }
    }

    public class TargetFrameworkDto
    {
        public string Name { get; set; }
        public IEnumerable<PackageDto> Packages { get; set; }
    }

    public class PackageDto
    {
        public string Name { get; set; }
    }
}
