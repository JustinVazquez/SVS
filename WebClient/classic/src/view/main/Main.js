Ext.define('SVSClient.view.main.Login', {
    extend: 'Ext.Panel',
    xtype: 'app-main',

    requires: [
        'SVSClient.view.main.MainController',
        'SVSClient.view.main.MainModel',
    ],

    controller: 'main',
    viewModel: 'main',

    items:[{
        xtype: 'button',
        title: 'bla',
        text: 'bla',
    }]
});