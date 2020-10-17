document.addEventListener("DOMContentLoaded", ready);

function ready() {
	const id = setInterval((e) => {
		const tags = document.getElementsByClassName('link');

		const tagA = tags[0];

		try {
			tagA.href = "https://logikoz.net";

			tagA.children[0].src = "/docs/logo.svg";

			clearInterval(id);
		}
		catch{
		}
	}, 100);
};