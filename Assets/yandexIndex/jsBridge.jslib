mergeInto(LibraryManager.library, {
  ShowAd: function () {
      if (window.unityShowAd) {
            window.unityShowAd();
        }
    }
});