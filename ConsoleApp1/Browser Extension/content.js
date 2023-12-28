// content.js

// This function gets injected into the tab and sends back specific elements' data
function tabScript() {
    console.log("tabScript");
    var divs = document.getElementsByClassName("swiper-no-swiping");
    var divsData = Array.from(divs).map(div => div.innerHTML); // or other relevant data
    chrome.runtime.sendMessage({ divsData: divsData });
}

// Rest of your content.js code to invoke tabScript...
