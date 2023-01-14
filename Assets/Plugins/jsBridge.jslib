mergeInto(LibraryManager.library, {
    ShowAd: function () {
        if (window.showAd) {
            window.showAd();
        }
    },

    PrefsSetInt: function (key, value) {
        let stringKey = UTF8toString(key);
        if (window.player == null || window.playerData == null) {
            return;
        }

        window.player.setData({stringKey, value}).then(console.log('data is set')).catch(err => console.log('data is not set: ' + err));
    },

    PrefsGetInt: function (key, defaultValue) {
        let stringKey = UTF8toString(key);
        if (window.playerData == null) {
            console.log("Null! Returned default");
            return defaultValue;
        }

        if (stringKey in window.playerData){
            console.log("Returned value");
            return window.playerData[stringKey];
        }

        console.log("Not found. Returned default");
        return defaultValue;
    },

    PrefsSetBool: function (key, value) {
        if (window.player == null || window.playerData == null) {
            return;
        }

        window.player.setData({key, value});
    },

    PrefsGetBool: function (key, defaultValue) {
        if (window.playerData == null) {
            return defaultValue;
        }

        if (key in window.playerData){
            return window.playerData[key];
        }

        return defaultValue;
    }
});