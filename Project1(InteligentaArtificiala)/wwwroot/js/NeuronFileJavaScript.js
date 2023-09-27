<script>
    document.addEventListener("DOMContentLoaded", function () {
        const incrementButtons = document.querySelectorAll(".increment-button");
        const decrementButtons = document.querySelectorAll(".decrement-button");

        const valueMap = new Map(); 
        incrementButtons.forEach((button) => {
            const field = button.getAttribute("data-field");
            const index = button.getAttribute("data-index");
            const span = document.querySelector(`[data-field="${field}"][data-index="${index}"]`);
            valueMap.set(`${field}_${index}`, parseFloat(span.textContent.replace(',', '.'))); 
            button.addEventListener("click", function () {
                const currentValue = valueMap.get(`${field}_${index}`);
                const newValue = (currentValue + 0.01).toFixed(2).replace('.', ','); 
                span.textContent = newValue;
                updateHiddenInput(field, index, newValue);
                valueMap.set(`${field}_${index}`, parseFloat(newValue.replace(',', '.'))); 
            });
        });

        decrementButtons.forEach((button) => {
            const field = button.getAttribute("data-field");
            const index = button.getAttribute("data-index");
            const span = document.querySelector(`[data-field="${field}"][data-index="${index}"]`);
            valueMap.set(`${field}_${index}`, parseFloat(span.textContent.replace(',', '.'))); 
            button.addEventListener("click", function () {
                const currentValue = valueMap.get(`${field}_${index}`);
                const newValue = (currentValue - 0.01).toFixed(2).replace('.', ','); 
                span.textContent = newValue;
                updateHiddenInput(field, index, newValue);
                valueMap.set(`${field}_${index}`, parseFloat(newValue.replace(',', '.'))); 
            });
        });

        function updateHiddenInput(field, index, value) {
            const input = document.querySelector(`input[name="${field}"][data-field="${field}"][data-index="${index}"]`);
            input.value = value;
        }
    });
</script>


<script>
    document.addEventListener("DOMContentLoaded", function () {
        const incrementButtons = document.querySelectorAll(".incrementt-button");
        const decrementButtons = document.querySelectorAll(".decrementt-button");

        incrementButtons.forEach((button) => {
            button.addEventListener("click", function () {
                const field = button.getAttribute("data-field");
                incrementDecrement(field, 0.01);
            });
        });

        decrementButtons.forEach((button) => {
            button.addEventListener("click", function () {
                const field = button.getAttribute("data-field");
                incrementDecrement(field, -0.01);
            });
        });

        function incrementDecrement(field, step) {
            const currentValue = parseFloat(document.querySelector(`#${field}Value`).textContent.replace(',', '.'));
            const newValue = (currentValue + step).toFixed(2).replace('.', ',');
            document.querySelector(`#${field}Value`).textContent = newValue;
            updateHiddenInput(field, newValue);
        }

        function updateHiddenInput(field, value) {
            document.querySelector(`input[name="${field}"]`).value = value;
        }
    });
</script>
