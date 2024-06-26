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
        .then(categoriesData => {
            _displayCategories(categoriesData);
            return categoriesData; // Return the categories data
        })
        .catch(error => console.error('Unable to get categories.', error));
}

function _displayCategories(categoriesData) {
    const selectCategories = document.getElementById('filtercategory');
    const selectEditCategories = document.getElementById('categoryToEdit');
    const selectAddTransactionCategory = document.getElementById('transactionCategory');

    // Clear existing options
    while (selectCategories.options.length > 1) {
        selectCategories.remove(1);
    }
    while (selectEditCategories.options.length > 1) {
        selectEditCategories.remove(1);
    }
    while (selectAddTransactionCategory.options.length > 1) {
        selectAddTransactionCategory.remove(1);
    }

    categoriesData.forEach(category => {
        // Create an option for selectCategories
        var selectOption = document.createElement("option");
        selectOption.textContent = category.description;
        selectCategories.add(selectOption);

        // Create an option for selectEditCategories
        var selectEditOption = document.createElement("option");
        selectEditOption.textContent = category.description;
        selectEditCategories.add(selectEditOption);

        // Create an option for add transaction modal
        var selectAddTransactionOption = document.createElement("option");
        selectAddTransactionOption.textContent = category.description;
        selectAddTransactionCategory.add(selectAddTransactionOption);

        selectEditCategories.options[0].textContent = 'Select category';
        selectAddTransactionCategory.options[0].textContent = 'Select category';
    });
}


function _displayTransactions(transactionsData, categoriesData) {
    const tBody = document.getElementById('transactions');

    let categoryMap = {};
    categoriesData.forEach(category => {
        categoryMap[category.id] = category.description;
    });

    const button = document.createElement('button');

    transactionsData.forEach(transaction => {
        let editButton = document.createElement('button');
        editButton.classList.add('btn', 'btn-md');
        editButton.style.width = '100%';
        editButton.style.fontWeight = 'bold';

        let text = document.createTextNode(' Edit');
        editButton.appendChild(text);

        editButton.onclick = function () {
            displayEditForm(transaction.id);
        };
    

    let deleteButton = document.createElement('button');
    deleteButton.classList.add('btn', 'btn-md');
    deleteButton.style.width = '100%';
    deleteButton.style.fontWeight = 'bold';

    let deleteText = document.createTextNode(' Delete');
    deleteButton.appendChild(deleteText);

    deleteButton.onclick = function () {
        deleteTransaction(transaction.id);
        };

        let tr = tBody.insertRow();
        tr.classList.add('align-middle');

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
            year: 'numeric'
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

function filterTransactions(){
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("filterdescription");
    filter = input.value.toUpperCase();
    table = document.getElementById("transactions");
    tr = table.getElementsByTagName("tr");

    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[0];
        if (td) {
          txtValue = td.textContent || td.innerText;
          if (txtValue.toUpperCase().indexOf(filter) > -1) {
            tr[i].style.display = "";
          } else {
            tr[i].style.display = "none";
          }
        }
      }
}

function filterDate() {
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("filterdate");
    filter = input.value;

    // Check if the input is empty and handle accordingly
    if (filter === "") {
        // If the input is empty, reset the filter to show all rows
        filter = null;
    } else {
        var selectedDate = new Date(filter);
        filter = selectedDate.toLocaleDateString('nl-BE', {
            day: '2-digit',
            month: '2-digit',
            year: 'numeric'
        });
    }

    table = document.getElementById("transactions");
    tr = table.getElementsByTagName("tr");
    
    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[2];
        if (td) {
            txtValue = td.textContent || td.innerText;
            
            var parts = txtValue.split('/'); 
            var formattedDate = parts[2] + '-' + parts[1] + '-' + parts[0];

            var dateFromRow = new Date(formattedDate);
            var formattedDateFromRow = dateFromRow.toLocaleDateString('nl-BE', {
                day: '2-digit',
                month: '2-digit',
                year: 'numeric'
            });

            // Adjust the condition to handle the case when filter is null
            if (!filter || formattedDateFromRow === filter) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}

function filterCategories() {
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("filtercategory");
    filter = input.value.toUpperCase();
    table = document.getElementById("transactions");
    tr = table.getElementsByTagName("tr");

    if (filter === "SELECT CATEGORY") {
        for (i = 0; i < tr.length; i++) {
            tr[i].style.display = "";
        }
        return;
    }

    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[3];
        if (td) {
          txtValue = td.textContent || td.innerText;
          if (txtValue.toUpperCase().indexOf(filter) > -1) {
            tr[i].style.display = "";
          } else {
            tr[i].style.display = "none";
          }
        }
      }
}