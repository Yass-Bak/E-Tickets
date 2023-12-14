
	document.addEventListener('DOMContentLoaded', function () {
		const stars = document.querySelectorAll('.star');
	const noteInput = document.getElementById('Note');

		stars.forEach(star => {
		star.addEventListener('click', () => {
			const value = star.getAttribute('data-value');
			noteInput.value = value;
			updateStars(value);
		});

			star.addEventListener('mouseover', () => {
				const value = star.getAttribute('data-value');
	updateStars(value);
			});

			star.addEventListener('mouseout', () => {
				const activeValue = noteInput.value;
	updateStars(activeValue);
			});
		});

	function updateStars(value) {
		stars.forEach(star => {
			const starValue = star.getAttribute('data-value');
			star.classList.toggle('active', starValue <= value);
		});
		}
	});