$(function() {
	$("#auth").click (function(){
		$.post( "http://localhost:8080/authenticate",
			JSON.stringify({password:"xyzzy", numder:"3"}),
			function( data ) {
				$( ".result" ).html( data );
			}
		);
	});
});