function openModal(id) {
    const modal = document.getElementById(id);
    modal.style.display = "block";

    const modalContent = modal.querySelector('.modal-content');
    modalContent.style.top = "100px";        // starting top
    modalContent.style.left = "50%";         // starting left
    modalContent.style.transform = "translateX(-50%)"; // center horizontally
    
    if (id == 'statusModal'){
        initPage();
    }
}

function initPage() {
    const rows = document.querySelectorAll("#reportPage tr");
    if (!rows.length) return;

    const rowsPerPage = 5;
    let currentPage = 1;
    const totalPages = Math.ceil(rows.length / rowsPerPage);

    function showPage(page) {
        const start = (page - 1) * rowsPerPage;
        const end = page * rowsPerPage;

        rows.forEach((row, index) => {
            row.style.display = (index >= start && index < end) ? "" : "none";
        });

        document.getElementById("pageInfo").textContent = `Page ${page} of ${totalPages}`;
        document.getElementById("prevBtn").disabled = page == 1;
        document.getElementById("nextBtn").disabled = page == totalPages;
    }

    window.changePage = function(direction) {
        currentPage += direction;
        if (currentPage < 1) currentPage = 1;
        if (currentPage > totalPages) currentPage = totalPages;
        showPage(currentPage);
    }

    showPage(currentPage);
    
}



document.addEventListener("DOMContentLoaded", function(){
    const clearBtn = document.getElementById("clearImgBtn");
    const fileInput = document.getElementById("attach");
    
    if (clearBtn && fileInput) {
        clearBtn.addEventListener("click", function(){
        fileInput.value = "";})
    }
});

function closeModal(id) {
    document.getElementById(id).style.display = "none";
}

let activeModal = null;
let offsetX = 0, offsetY = 0;

document.querySelectorAll('.modal-header').forEach(header => {
    header.addEventListener('mousedown', function(e) {
        const modalContent = header.parentElement;

        // Remove horizontal centering transform when starting drag
        modalContent.style.transform = "";

        activeModal = modalContent;
        offsetX = e.clientX - modalContent.offsetLeft;
        offsetY = e.clientY - modalContent.offsetTop;

        document.addEventListener('mousemove', dragModal);
        document.addEventListener('mouseup', stopDrag);
    });
});

function dragModal(e) {
    if (!activeModal) return;
    activeModal.style.left = (e.clientX - offsetX) + 'px';
    activeModal.style.top = (e.clientY - offsetY) + 'px';
}

function stopDrag() {
    document.removeEventListener('mousemove', dragModal);
    document.removeEventListener('mouseup', stopDrag);
    activeModal = null;
}

// Close modal if clicking outside
window.onclick = function(event) {
    document.querySelectorAll('.modal').forEach(modal => {
        if (event.target === modal) modal.style.display = "none";
    });
};

function showToast(message, duration = 3000) {
    const toast = document.getElementById("toast");
    if (!toast) return;
    
    toast.textContent = message;
    toast.classList.add("show");
    
    setTimeout(() => {
        toast.classList.remove("show");
    }, duration);
}