chrome.runtime.onMessage.addListener(
    function (request, sender, sendResponse) {
        // Receive the HTML from content script
        if (request.html) {
            var blob = new Blob([request.html], { type: "text/html" });

            // Use the FileReader to convert the Blob into a Data URL
            var reader = new FileReader();
            reader.onload = function () {
                if (reader.result) {
                    // Trigger the download
                    chrome.downloads.download({
                        url: reader.result,
                        filename: "downloaded_page.html" // Optional: you can choose the file name
                    });
                }
            };
            reader.readAsDataURL(blob);
        }
    }
);