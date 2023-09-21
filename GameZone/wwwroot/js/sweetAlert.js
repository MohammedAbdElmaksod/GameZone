var sweetAlert = {
    DeleteAlert: function (area, controller, action, id) {
        swal.fire({
            title: 'Delete',
            text: 'Are you sure to delete it!',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: 'Yes, Delete it',
            confirmButtonColor: '#fe7c96',
            background: '#222328',
        }).then((result) => {
            if (result.isConfirmed) {
                if (area.length > 0) {
                    window.location.href = `/${area}/${controller}/${action}/${id}`
                }
                else {
                    window.location.href = `/${controller}/${action}/${id}`
                }
            }
        })
    }
}