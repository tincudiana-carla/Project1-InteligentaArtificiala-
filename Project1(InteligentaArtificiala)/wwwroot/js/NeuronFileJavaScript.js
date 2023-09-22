<script>
    document.addEventListener("DOMContentLoaded", function () {
        const incrementButtons = document.querySelectorAll(".increment-button");
    const decrementButtons = document.querySelectorAll(".decrement-button");
        
        incrementButtons.forEach((button) => {
        button.addEventListener("click", function () {
            const field = button.getAttribute("data-field");
            const index = button.getAttribute("data-index");
            const span = document.querySelector(`[data-field="${field}"][data-index="${index}"]`);
            const currentValue = parseFloat(span.textContent);
            const newValue = (currentValue + 0.01).toFixed(2);
            span.textContent = newValue;
        });
        });

        decrementButtons.forEach((button) => {
        button.addEventListener("click", function () {
            const field = button.getAttribute("data-field");
            const index = button.getAttribute("data-index");
            const span = document.querySelector(`[data-field="${field}"][data-index="${index}"]`);
            const currentValue = parseFloat(span.textContent);
            const newValue = (currentValue - 0.01).toFixed(2);
            span.textContent = newValue;
        });
        });
    });
</script>
