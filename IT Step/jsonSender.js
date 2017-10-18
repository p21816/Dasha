$(function() {
	$("#auth").click (function(){
		$.post( "http://localhost:8080/authenticate",
			JSON.stringify({password:"xyzzy"}),
			function( data ) {
				$( ".result" ).html( data );
			}
		);
	});
});