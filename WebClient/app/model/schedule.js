Ext.define('SVSClient.model.schedule', {
    extend: 'Ext.data.Model',
    fields: ['classID', 'schedule'],

    proxy: {
        type: 'ajax',
        api: {
            create: '/api/values'
        },
        reader: {
            root: 'data'
        }
    }
});
