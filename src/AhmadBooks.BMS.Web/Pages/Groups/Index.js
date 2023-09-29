$(function () {
    var l = abp.localization.getResource('BMS');
    var createModal = new abp.ModalManager(abp.appPath + 'Groups/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Groups/EditModal');

    var dataTable = $('#GroupsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: true,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(ahmadBooks.bMS.groups.group.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible:
                                        abp.auth.isGranted('BMS.Groups.Edit'),
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    visible:
                                        abp.auth.isGranted('BMS.Groups.Delete'),
                                    confirmMessage: function (data) {
                                        return l(
                                            'GroupDeletionConfirmationMessage',
                                            data.record.name
                                        );
                                    },
                                    action: function (data) {
                                        ahmadBooks.bMS.groups.group
                                            .delete(data.record.id)
                                            .then(function () {
                                                abp.notify.info(
                                                    l('SuccessfullyDeleted')
                                                );
                                                dataTable.ajax.reload();
                                            });
                                    }
                                }
                            ]
                    }
                },
                {
                    title: l('Name'),
                    data: "name"
                }
            ]
        })
    );

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewGroupButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
