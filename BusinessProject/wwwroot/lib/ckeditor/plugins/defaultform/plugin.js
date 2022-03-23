CKEDITOR.plugins.add('defaultform', {

    init: function (editor) {
        editor.ui.addButton('defaultForm', {
            label: "Default Content Form",
            command: "defaultcommnd"
            //toolbar: "insert"
        })

        //editor.addCommand('defaultcommnd', {
        //    exec: function (editor) {
        //        alert('salam');
        //    }
        //})
    }
});