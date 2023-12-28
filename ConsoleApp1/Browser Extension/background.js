// background.js



// background.js
chrome.runtime.onMessage.addListener(function (request, sender, sendResponse) {
    console.log("OnMessge", request);
    if (request.divsData) {
        // Now request.divsData is an array of HTML strings from the .swiper-no-swiping elements
        // You can directly use this data or initiate a download as you need
        console.log("Received data from content script: ", request.divsData);

        //var divs = request.document.getElementsByClassName("swiper-no-swiping");

        var htmlText;

        // Loop through each div using for...of and append its text content to the plainText variable
        request.divsData.forEach(function (div) {
            htmlText += div + '\n';
        });

        var blob = new Blob([htmlText], { type: "text/txt" });

        var reader = new FileReader();
        reader.onload = function () {
            if (reader.result) {

                chrome.downloads.download({
                    url: reader.result,
                    filename: "ExportedChat.txt"
                });

            }
        };
        reader.readAsDataURL(blob);
    }
});


//chrome.runtime.onMessage.addListener(function (request, sender, sendResponse) {
//    if (request.html) {

//        console.log("Test : ", request.html);
//        var divs = request.html.getElementsByClassName("swiper-no-swiping");

//        var htmlText;
//        // Loop through each div using for...of and append its text content to the plainText variable
//        Array.from(divs).forEach(function (div) {
//            htmlText += div.children[0].outerHTML + '\n';
//        });

//        var blob = new Blob([htmlText], { type: "text/txt" });

//        var reader = new FileReader();
//        reader.onload = function () {
//            if (reader.result) {

//                chrome.downloads.download({
//                    url: reader.result,
//                    filename: "ExportedChat.txt"
//                });

//            }
//        };
//        reader.readAsDataURL(blob);
//    }
//});