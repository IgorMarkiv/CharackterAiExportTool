console.log("Current Tab Title:", document.title);




// content.js
// Get the HTML of the current document
var htmlContent = document.documentElement.outerHTML;

// Send the HTML content to the background script
chrome.runtime.sendMessage({ html: htmlContent });

//function Export() {

//    var divs = document.getElementsByClassName("swiper-no-swiping");

//    var htmlText;
//    // Loop through each div using for...of and append its text content to the plainText variable
//    Array.from(divs).forEach(function (div) {
//        htmlText += div.children[0].outerHTML + '\n';
//    });

//    let blob = new Blob([htmlText], { type: 'text/plain' });

//    let downloadLink = document.createElement("a");

//    downloadLink.download = "myFile.txt";

//    downloadLink.href = window.URL.createObjectURL(blob);

//    document.body.appendChild(downloadLink); // Needed for Firefox

//    downloadLink.click();
//}