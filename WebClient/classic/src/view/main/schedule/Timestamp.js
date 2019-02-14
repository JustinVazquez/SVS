Ext.define('SVSClient.view.main.schedule.Timestamp', {
    extend: 'Ext.Panel',
    xtype: 'timestamp',
    requires: [
        // 'SVSClient.view.login.LoginController',
        // 'SVSClient.view.login.LoginModel',
        // 'SVSClient.view.main.Main',
        'Ext.form.Panel'
    ],
    // controller: 'schedule',
    // viewModel: 'schedule',
    closable: false,
    autoShow: true,
    modal: false,
    draggable: false,
    resizable: false,
    shim: false,
    shadow: false,
    onEsc: Ext.emptyFn,
    cls: 'timestamp',
    id: 'timestamp',
    itemId: 'timestamp',
    height: '100%',
    width: '100%',
    renderTo: document.body,
    items:[
        {
            xtype: 'panel',
            title: '8:00 - 8:45',
            cls: 'timestampPanels',
        },
        {
            xtype: 'panel',
            title: '8:45 - 9:30',
            cls: 'timestampPanels',
        },
        {
            xtype: 'panel',
            title: '9:45 - 10:30',
            cls: 'timestampPanels',
        },
        {
            xtype: 'panel',
            title: '10:30 - 11:15',
            cls: 'timestampPanels',
        },
        {
            xtype: 'panel',
            title: '11:30 - 12:15',
            cls: 'timestampPanels',
        },
        {
            xtype: 'panel',
            title: '12:15 - 13:00',
            cls: 'timestampPanels',
        },
        {
            xtype: 'panel',
            title: '13:15 - 14:00',
            cls: 'timestampPanels',
        },
        {
            xtype: 'panel',
            title: '14:00 - 14:45',
            cls: 'timestampPanels',
        },
    ]
});
