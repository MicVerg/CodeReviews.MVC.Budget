const uriTransactions = 'https://localhost:7129/api/transactions';
const uriCategories = 'https://localhost:7129/api/categories';
let transactions = [];
let categories = [];
function getTransactions() {
    return fetch(uriTransactions)
        .then(response => response.json())
        .then(transactionsData => {
            return getCategories()
                .then(categoriesData => {
                    _displayTransactions(transactionsData, categoriesData);
                });
        })
        .catch(error => console.error('Unable to get transactions.', error));
}


function getCategories() {
    return fetch(uriCategories)
        .then(response => response.json())
        .catch(error => console.error('Unable to get categories.', error));
}


function _displayTransactions(transactionsData, categoriesData) {
    const tBody = document.getElementById('transactions');
    tBody.innerHTML = '';

    let categoryMap = {};
    categoriesData.forEach(category => {
        categoryMap[category.id] = category.description;
    });

    const button = document.createElement('button');

    transactionsData.forEach(transaction => {
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

        let td2 = tr.insertCell(1);
        let transactionType;
        if (transaction.transactionType == 1) {
            transactionType = '-';
        } else if (transaction.transactionType == 0) {
            transactionType = '+';
        }
        let textNodeAmount = (document.createTextNode(transactionType + ' €' + transaction.amount));
        td2.appendChild(textNodeAmount);

        let td3 = tr.insertCell(2);
        let transactionDate = new Date(transaction.date);
        let formattedDate = transactionDate.toLocaleDateString('nl-BE', {
            day: '2-digit',
            month: '2-digit',
            year: '2-digit'
        });
        let textNodeDate = (document.createTextNode(formattedDate));
        td3.appendChild(textNodeDate);

        let categoryDescription = categoryMap[transaction.categoryId];
        let td4 = tr.insertCell(3);
        let textNodeCategory = (document.createTextNode(categoryDescription));
        td4.appendChild(textNodeCategory);

        let td5 = tr.insertCell(4);
        td5.classList.add('col-1');
        td5.appendChild(editButton);
        td5.appendChild(deleteButton);
    });
    transactions = transactionsData;
    categories = categoriesData;
}

function deleteTransaction(id) {
    fetch(`${uriTransactions}/${id}`, {
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