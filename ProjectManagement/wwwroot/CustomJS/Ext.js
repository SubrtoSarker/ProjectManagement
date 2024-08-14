function printDiv(divId) {
    var divToPrint = document.getElementById(divId);
    var newWindow = window.open('', '', 'height=600,width=800');
    newWindow.document.write('<html><head><title>Print</title>');
    newWindow.document.write('</head><body >');
    newWindow.document.write(divToPrint.outerHTML);
    newWindow.document.write('</body></html>');
    newWindow.document.close();
    newWindow.print();
}
function downloadFile(fileName, fileContentBase64) {
    var link = document.createElement('a');
    link.href = 'data:application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;base64,' + fileContentBase64;
    link.download = fileName;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}