function UpdateLength(max)
{
    var lengthElement = document.getElementById("LengthCount");        

    var length = parseInt(document.getElementById("Message").value.length, 10);

    lengthElement.innerText = max - length;    
}

//function CopyToClipboard()
//{
//    var element = document.getElementById("LinkLabel");
//    var text = element.innerText;

//    document.getElementById("copyButton").className = "copied";

//    window.clipboardData.setData("Text", text);
//}

