$(document).ready(function () {
    $('.js-delete').on('click', function () {
        var btn = $(this);
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
                $.ajax({
                    url: `/Games/DeleteGame/${btn.data('id')}`,
                    method: 'DELETE',
                    success: function () {
                        swal.fire({
                            title: 'Deleted',
                            Text: 'the game was deleted',
                            icon: 'success',
                            background: '#222328'
                        });
                        btn.parents('tr').fadeOut(1000);
                    },
                    error: function () {
                        swal.fire({
                            title: 'oops',
                            Text: 'something went wrong',
                            icon: 'error',
                            background: '#222328'
                        })
                    }
                })
            }
        })

    });
});