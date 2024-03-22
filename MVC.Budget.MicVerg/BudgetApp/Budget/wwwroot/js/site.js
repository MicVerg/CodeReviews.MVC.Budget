const uri = 'https://localhost:7129/api/transactions';
let transactions = [];
function getTransactions() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayTransactions(data))
        .catch(error => console.error('Unable to get transactions.', error));
}

function _displayTransactions(data) {
    const tBody = document.getElementById('transactions');
    tBody.innerHTML = '';

    const button = document.createElement('button');

    data.forEach(transaction => {
        let editButton = document.createElement('button');
        editButton.classList.add('btn', 'btn-warning', 'btn-md');
        editButton.style.width = '100%';
        editButton.style.fontWeight = 'bold';

        let icon = document.createElement('i');
        icon.classList.add('bi', 'bi-pencil-fill');
        editButton.appendChild(icon);

        let text = document.createTextNode(' Edit');
        editButton.appendChild(text);

        editButton.onclick = function () {
            displayEditForm(transaction.id);
        };
    

    let deleteButton = document.createElement('button');
    deleteButton.classList.add('btn', 'btn-danger', 'btn-md');
    deleteButton.style.width = '100%';
    deleteButton.style.fontWeight = 'bold';

    let deleteIcon = document.createElement('i');
    deleteIcon.classList.add('bi', 'bi-x-circle-fill');
    deleteButton.appendChild(deleteIcon);

    let deleteText = document.createTextNode(' Delete');
    deleteButton.appendChild(deleteText);

    deleteButton.onclick = function () {
        deleteTransaction(transaction.id);
        };

        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);
        let textNodeDescription = (document.createTextNode(transaction.description));
        td1.appendChild(textNodeDescription);
    });

    transactions = data;
}

function deleteTransaction(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getTransactions())
        .catch(error => console.error('Unable to delete item.', error));
}

function displayEditForm(id) {
    const transaction = transactions.find(transaction => transaction.id === id);

    document.getElementById('edit-name').value = transaction.description;
    document.getElementById('edit-id').value = transaction.id;
    document.getElementById('editForm').style.display = 'block';
}