$(function ()  {
	var message = '@toastrMessage';
	var type = '@toastrType';

	if (message) {

		toastr.options = {
			"closeButton": true,
			"progressBar": true,
			"positionClass": "toast-center", // Custom class for centering
			"timeOut": "5000", // 5-second timeout for the notification
			"showDuration": "300",
			"hideDuration": "1000",
			"extendedTimeOut": "1000",
		};
		// Display Toastr notification
		toastr[type](message); // E.g., toastr.success(), toastr.error(), etc.
	}
})