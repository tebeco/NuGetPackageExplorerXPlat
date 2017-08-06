const builder = require("electron-builder")
const Platform = builder.Platform

// Promise is returned 
builder.build({
    targets: Platform.WINDOWS.createTarget(),
    config: {
        "appId": "cross-platform-desktop",
        "directories": {
            "output": "../dist"
        },
        "extraResources": {
            "from": "../api/dist/",
            "to": "../api/",
            "filter": [
                "**/*"
            ]
        },
        "win": {
            "target": [
                "NSIS"
            ]
        }
    }
})
    .then(() => {
        console.log('Ok');
    })
    .catch((error) => {
        console.error('Failed :', error);
        // handle error 
    })
