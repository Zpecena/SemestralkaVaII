const desc = document.getElementById('desc')
const form = document.getElementById('form')
const errorElement = document.getElementById('error')
form.addEventListener('submit', (e) => {
    let messages = []
    if (desc.value == '' || desc.value == null) {
        messages.push('Descriptiom of order is Required')


    if (desc.value.length < 15) {
        messages.push('Order must be longer than 15 letters.')
    }

    if (desc.value.length > 100) {
        messages.push('Order must be shorter than 100 letters.')
    }

    if (desc.value.match(/^[0-9]+$/) != null)
    {
        messages.push('Order Cannot be only Numbers.')
    }

    if (messages.length > 0) {
        e.preventDefault();
        errorElement.innerText = messages.join(',')
    }
})

