function pptupload() {

    var inputfile = document.querySelector('#pptfile');
    inputfile.addEventListener('change', (e) => {
        console.log(e.target.files); // get file object
        var teacher = "test";
        var course = "001";
        var fd = new FormData();
        fd.append("teacher", teacher);
        fd.append("course", course);
        var ppt = inputfile.files[0];
        fd.append('file', ppt);
        fd.append("ppttype", "Test");
        pptshow.src = "http://192.192.155.110/Api/uploadppt/6.png";
        $.ajax({
            type: "POST",
            dataType: "json",
            url: "http://192.192.155.110/Api/Api/test",
            data: fd,
            contentType: false,
            processData: false,
            async: false
        }).success(function (r) {
            console.log(r)


        });
    });
    

}
