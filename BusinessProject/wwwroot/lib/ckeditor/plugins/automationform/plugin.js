CKEDITOR.plugins.add('automationform', {

    init: function (editor) {
        editor.ui.addButton('automationform', {
            label: "Automation Forms",
            command: "automationform"
            //toolbar: "insert"
        })


    }
});