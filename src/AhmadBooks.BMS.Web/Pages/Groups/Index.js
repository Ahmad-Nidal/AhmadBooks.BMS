$(function () {
    var l = abp.localization.getResource('BMS');

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
                                    text: l('Enroll'),
                                    visible:
                                        function (data) {
                                            return (
                                                abp.currentUser.isAuthenticated // &&
                                                //!ahmadBooks.bMS.groups.publicGroup.isEnrolled(data.record.id) // not working!
                                            )
                                        },
                                    action: function (data) {
                                        ahmadBooks.bMS.groups.publicGroup
                                            .enrollToGroup({ id: data.record.id })
                                            .then(function () {
                                                abp.notify.info(
                                                    l('SuccessfullyEnrolled')
                                                );
                                                dataTable.ajax.reload();
                                            })
                                    }
                                },
                                {
                                    text: l('Unenroll'),
                                    visible:
                                        function (data) {
                                            return (
                                                abp.currentUser.isAuthenticated // &&
                                                //ahmadBooks.bMS.groups.publicGroup.isEnrolled(data.record.id) // not working!
                                            )
                                        },
                                    action: function (data) {
                                        ahmadBooks.bMS.groups.publicGroup
                                            .unenrollToGroup({ id: data.record.id })
                                            .then(function () {
                                                abp.notify.info(
                                                    l('Successfullyunenrolled')
                                                );
                                                dataTable.ajax.reload();
                                            })
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
});
