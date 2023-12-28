// background.js
chrome.runtime.onMessage.addListener(function (request, sender, sendResponse) {
    if (request.html) {
        var blob = new Blob([request.html], { type: "text/html" });

        var reader = new FileReader();
        reader.onload = function () {
            if (reader.result) {
                chrome.downloads.download({
                    url: reader.result,
                    filename: "downloaded_page.html"
                });
            }
        };
        reader.readAsDataURL(blob);
    }
});