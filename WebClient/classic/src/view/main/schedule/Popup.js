Ext.define('SVSClient.view.main.schedule.Popup',{
    xtype: 'popup',
    extend:'Ext.Panel',
    itemId: 'popup',
    id: 'popup',
    floating: true,
    centered: true,
    modal: true,
    width: 500,
    height: 300,
    cls: 'popup',
    styleHtmlContent: true,
    items:[
        {
            xtype: 'panel',
            height: 30,
            width: '100%',
            items:[
                {
                    xtype: 'button',
                    cls: 'closePopupButton',
                    text: 'Close',
                    handler: function(){
                        this.ownerCt.ownerCt.hide()
                    }
                }
            ]
        },
        {
            xtype: 'panel',
            height: 50,
            width: '100%',
            cls: 'popupTitle',
            title: 'Configure Schedule'
        },
        {
            xtype: 'container',
            height: 170,
            width: '100%',
            items:[
                {
                    xtype: 'container',
                    height: 57,
                    items:[
                        {
                            xtype: 'textfield',
                            name: 'subject',
                            id: 'subject',
                            itemId: 'subject',
                            cls: 'popupFields',
                            emptyText: 'Subject',
                            allowBlank: false,
                            selectOnFocus: true,
                            listeners: {
                                afterrender: function (field) {
                                    setTimeout(function() {
                                        field.inputEl.dom.focus();
                                    }, 500);
                                }
                            },
                            inputAttrTpl: 'autocapitalize=off'
                        }
                    ]
                },
                {
                    xtype: 'container',
                    height: 57,
                    items:[
                        {
                            xtype: 'textfield',
                            name: 'room',
                            id: 'room',
                            itemId: 'room',
                            cls: 'popupFields',
                            emptyText: 'Room',
                            allowBlank: false,
                            selectOnFocus: true,
                            listeners: {
                                afterrender: function (field) {
                                    setTimeout(function() {
                                        field.inputEl.dom.focus();
                                    }, 500);
                                }
                            },
                            inputAttrTpl: 'autocapitalize=off'
                        }
                    ]
                },
                {
                    xtype: 'container',
                    height: 57,
                    items:[
                        {
                            xtype: 'textfield',
                            name: 'status',
                            id: 'status',
                            itemId: 'status',
                            cls: 'popupFields',
                            emptyText: 'Status',
                            allowBlank: false,
                            selectOnFocus: true,
                            listeners: {
                                afterrender: function (field) {
                                    setTimeout(function() {
                                        field.inputEl.dom.focus();
                                    }, 500);
                                }
                            },
                            inputAttrTpl: 'autocapitalize=off'
                        }
                    ]
                }
            ]
        },
        {
            xtype: 'button',
            height: 50,
            width: '100%',
            title: 'Send',
            handler: 'sendChanges',
        }
    ]
});