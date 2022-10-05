function fileupload(filename)
{
    var inoutfile = document.getElementById(filename);
    var files = window.inputfile.files;
    var fdata = new FormData();
    for (var i = 0; i !== files.length; i++) {
        data.append("files", files[i]);
    }
    $.ajax(
        {
            url:"/files/upload",
            data: fdata,
            processData: false,
            ContentType: false,
            type: "POST",
            success: function(data) {
                alert("File Upload Successfully");
            }
        }
    );
}
