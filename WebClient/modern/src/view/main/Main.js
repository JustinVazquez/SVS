Ext.define('SVSClient.view.main.Main', {
    extend: 'Ext.Panel',
    xtype: 'app-main',

    requires: [
        'SVSClient.view.main.MainController',
        'SVSClient.view.main.MainModel',
    ],

    controller: 'main',
    viewModel: 'main',

    items: [{
        xtype: 'container',
        title: 'Home',
        items:[
            {
            xtype: 'button',
            height: 50,
            width: 50,
        },
        {
            xtype: 'panel',
            itemId: 'crap-panel',
            id: 'crap-panel',
            height:100,
            width:200,
            title: 'Test'
        }
        ]
    }]
});
