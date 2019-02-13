Ext.define('SVSClient.store.schedules', {
    extend: 'Ext.data.Store',
    model: 'SVSClient.model.schedule',
    autoLoad: true,
    proxy: {
        type: 'ajax',
        api: {
            read: '/api/values',
            create: '/api/values/new'
        },
        reader: {
            type: 'json',
            root: 'data',
            successProperty: 'success'
        }
    }

});
