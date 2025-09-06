function openModal(id) {
    const modal = document.getElementById(id);
    modal.style.display = "block";
    /*(W3 Schools, 2025)*/

    const modalContent = modal.querySelector('.modal-content');
    /*(Mdn, 2025)*/
    modalContent.style.top = "100px";
    modalContent.style.left = "50%";
    modalContent.style.transform = "translateX(-50%)";
    /*(W3 Schools, 2025)*/
    
    if (id == 'statusModal'){
        initPage();
        /*(W3 Schools, 2025)*/
    }
}

function initPage() {
    const rows = document.querySelectorAll("#reportPage tr");
    if (!rows.length) return;
    /*(W3 Schools, 2025)*/

    const rowsPerPage = 5;
    let currentPage = 1;
    const totalPages = Math.ceil(rows.length / rowsPerPage);
    /*(W3 Schools, 2025)*/

    function showPage(page) {
        const start = (page - 1) * rowsPerPage;
        /*(Mdn, 2025)*/
        const end = page * rowsPerPage;
        /*(W3 Schools, 2025)*/

        rows.forEach((row, index) => {
            row.style.display = (index >= start && index < end) ? "" : "none";
            /*(W3 Schools, 2025)*/
        });

        document.getElementById("pageInfo").textContent = `Page ${page} of ${totalPages}`;
        document.getElementById("prevBtn").disabled = page == 1;
        document.getElementById("nextBtn").disabled = page == totalPages;
        /*(W3 Schools, 2025)*/
    }

    window.changePage = function(direction) {
        currentPage += direction;
        if (currentPage < 1) currentPage = 1;
        if (currentPage > totalPages) currentPage = totalPages;
        /*(Mdn, 2025)*/
        showPage(currentPage);
        /*(W3 Schools, 2025)*/
    }

    showPage(currentPage);
    /*(W3 Schools, 2025)*/
    
}



document.addEventListener("DOMContentLoaded", function(){
    const clearBtn = document.getElementById("clearImgBtn");
    const fileInput = document.getElementById("attach");
    /*(W3 Schools, 2025)*/
    
    if (clearBtn && fileInput) {
        clearBtn.addEventListener("click", function(){
        fileInput.value = "";})
        /*(W3 Schools, 2025)*/
    }
});

function closeModal(id) {
    document.getElementById(id).style.display = "none";
    /*(W3 Schools, 2025)*/
}

let activeModal = null;
let offsetX = 0, offsetY = 0;

document.querySelectorAll('.modal-header').forEach(header => {
    header.addEventListener('mousedown', function(e) {
        const modalContent = header.parentElement;
        /*(W3 Schools, 2025)*/

        modalContent.style.transform = "";
        /*(Mdn, 2025)*/

        activeModal = modalContent;
        offsetX = e.clientX - modalContent.offsetLeft;
        offsetY = e.clientY - modalContent.offsetTop;
        /*(W3 Schools, 2025)*/

        document.addEventListener('mousemove', dragModal);
        document.addEventListener('mouseup', stopDrag);
        /*(W3 Schools, 2025)*/
    });
});

function dragModal(e) {
    if (!activeModal) return;
    activeModal.style.left = (e.clientX - offsetX) + 'px';
    activeModal.style.top = (e.clientY - offsetY) + 'px';
    /*(W3 Schools, 2025)*/
}

function stopDrag() {
    document.removeEventListener('mousemove', dragModal);
    document.removeEventListener('mouseup', stopDrag);
    /*(Mdn, 2025)*/
    activeModal = null;
    /*(W3 Schools, 2025)*/
}


window.onclick = function(event) {
    document.querySelectorAll('.modal').forEach(modal => {
        if (event.target === modal) modal.style.display = "none";
        /*(W3 Schools, 2025)*/
    });
};

function showToast(message, duration = 3000) {
    const toast = document.getElementById("toast");
    /*(Mdn, 2025)*/
    if (!toast) return;
    /*(W3 Schools, 2025)*/
    
    toast.textContent = message;
    toast.classList.add("show");
    /*(W3 Schools, 2025)*/
    
    setTimeout(() => {
        toast.classList.remove("show");
    }, duration);
    /*(W3 Schools, 2025)*/
}

/*
Reference List

Geeks For Geeks. 2025. SQLite Tutorial, 23 July 2025. [Online]. Available at: https://www.geeksforgeeks.org/sqlite/sqlite-tutorial/ [Accessed 4 September 2025].

Mdn. 2025. CSS styling basics, 2 September 2025. [Online]. Available at: https://developer.mozilla.org/en-US/docs/Learn_web_development/Core/Styling_basics [Accessed 4 September 2025].

Mdn. 2025. JavaScript, 8 July 2025. [Online]. Available at: https://developer.mozilla.org/en-US/docs/Web/JavaScript [Accessed 4 September 2025].

W3 Schools. 2025. How TO - Snackbar / Toast, [n.d.]. [Online]. Available at: https://www.w3schools.com/howto/howto_js_snackbar.asp [Accessed 4 September 2025].

W3 Schools. 2025. How TO - CSS/JS Modal, [n.d.]. [Online]. Available at: https://www.w3schools.com/howto/howto_css_modals.asp [Accessed 4 September 2025].

W3 Schools. 2025. JavaScript Tutorial, [n.d.]. [Online]. Available at: https://www.w3schools.com/js/ [Accessed 4 September 2025].

W3 Schools. 2025. CSS Introduction, [n.d.]. [Online]. Available at: https://www.w3schools.com/css/css_intro.asp [Accessed 4 September 2025].

W3 Schools. 2025. HTML Tutorial, [n.d.]. [Online]. Available at: https://www.w3schools.com/Html/ [Accessed 4 September 2025].

W3 Schools. 2025. C# Tutorial, [n.d.]. [Online]. Available at: https://www.w3schools.com/cs/index.php [Accessed 4 September 2025].
 */