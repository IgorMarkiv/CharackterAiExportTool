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
    chrome.runtime.sendMessage({ html: document.documentElement.outerHTML });
}