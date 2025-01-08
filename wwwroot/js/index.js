const rows_per_page = 20;
const row_array = [];

let pages = 0;
let rows = 0;
let count = 0;
let curr_page = 0;

function check_valid_data(node){
    return !(!node.checkValidity() || node.value === "");

}

function add_row(){
    const amount = document.getElementById("row-amount-field");
    const status = document.getElementById("row-status-field");
    const purpose = document.getElementById("row-purpose-field");

    let cont = true;
    if(!check_valid_data(amount)){
        amount.classList.add("required");
        amount.classList.remove("valid-data");
        cont = false;
    }
    else{
        amount.classList.remove("required");
        amount.classList.add("valid-data");
    }

    if(!check_valid_data(status)){
        status.classList.add("required");
        status.classList.remove("valid-data");
        cont = false;
    }

    else{
        status.classList.remove("required");
        status.classList.add("valid-data");
    }

    if(!check_valid_data(purpose)){
        purpose.classList.add("required");
        purpose.classList.remove("valid-data");
        cont = false;
    }
    else{
        purpose.classList.remove("required");
        purpose.classList.add("valid-data");
    }

    if(!cont) return;


    const row = document.createElement("tr");
    row.classList.add("data-row");

    const amount_cell = row.insertCell(0);
    const status_cell = row.insertCell(1);
    const purpose_cell = row.insertCell(2);
    amount_cell.classList.add("data-cell");
    status_cell.classList.add("data-cell");
    purpose_cell.classList.add("data-cell");

    row_array.push(row);

    update_pagination()
    display_rows(pages, false)
    rows++;
    count++;

    const formatCash = Intl.NumberFormat('en-US', {
        style: 'currency',
        currency: 'USD',
    }).format(amount.value);

    amount_cell.textContent = formatCash;
    status_cell.textContent = status.value;
    purpose_cell.textContent = purpose.value;

    amount.value = "";
    status.value = "";
    purpose.value = "";
}

function update_pagination() {
    if(rows === rows_per_page || (pages !== 0 && rows === 0)) {
        rows = 0;
        pages++;
        if(pages === 1){
            const span = this.document.getElementById("page-span");
            const btn = document.createElement("button");
            span.appendChild(btn);
            btn.innerText = (pages).toString();
            btn.name = "page-btn" + pages;
            btn.onclick = function() {display_rows(btn.innerText, true)};
            pages++;
        }
        const span = this.document.getElementById("page-span");
        const btn = document.createElement("button");
        btn.name = "page-btn" + pages;
        span.appendChild(btn);
        btn.innerText = (pages).toString();
        btn.onclick = function() {display_rows(btn.innerText, true); curr_page = btn.innerText; };
    }
}

function display_rows(page, new_page){
    const table = document.getElementById("main-table");
    if(new_page === true){
        table.innerHTML =
            "        <tr>\n" +
            "            <th id=\"row-amount\">Amount</th>\n" +
            "            <th id=\"row-status\">Status</th>\n" +
            "            <th id=\"row-purpose\">Purpose</th>\n" +
            "        </tr>"
        for(let i= (page - 1) * rows_per_page; i < ((page - 1) * rows_per_page) + rows_per_page; i++){
            try{
                table.appendChild(row_array[i]);
            }
            catch(err){
                break;
            }
        }
    }
    else{
        if(pages === Number(curr_page)){
            table.appendChild(row_array[count]);
        }
    }
}