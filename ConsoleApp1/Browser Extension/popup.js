// popup.js
document.getElementById('downloadBtn').addEventListener('click', () => {
    chrome.tabs.query({ active: true, currentWindow: true }, function (tabs) {
        var activeTab = tabs[0];
        chrome.scripting.executeScript({
            target: { tabId: activeTab.id },
            function: tabScript
        });
    });
});

// This function gets injected into the tab and sends back the HTML
function tabScript() {

    console.log("tabScript 1");
    var divs = document.getElementsByClassName("swiper-no-swiping");

    var chatDivContent = [];

    for (var i = 0; i < divs.length; i++) {
        var div = divs[i];
        for (var i2 = 0; i2 < div.childElementCount; i2++) {

            var rawInnerHTML = div.children[i2].innerHTML;
            // Replace <br> with \n
            processedInnerHtml = rawInnerHTML.replace(/<br\s*[\/]?>/gi, "\n");

            // Replace <em> and </em> with *
            processedInnerHtml = processedInnerHtml.replace(/<em>/gi, "*").replace(/<\/em>/gi, "*");

            var conteainer = div.parentElement;

            processedInnerHtml = conteainer.children[0].children[0].innerText + " : " + processedInnerHtml;
            chatDivContent.push(processedInnerHtml);
        }
    }

    console.log("processedInnerHtml", processedInnerHtml);

    chrome.runtime.sendMessage({ chatDivContent: chatDivContent });
}