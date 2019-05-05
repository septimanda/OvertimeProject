function reject(id) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, reject it!'
    }).then((result) => {
        if (result.value) {
            $('#responsive-modal').modal('hide');
            Swal.fire(
              'Rejected!',
              'Your file has been rejected.',
              'success'
            )
        }
    })
}

function accept(id) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, accept it!'
    }).then((result) => {
        if (result.value) {
            $('#responsive-modal').modal('hide');
            Swal.fire(
              'Accepted!',
              'Your file has been accepted.',
              'success'
            )
        }
    })
}