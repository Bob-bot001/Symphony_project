// =============================================
// Symphony Limited - JavaScript
// =============================================

document.addEventListener('DOMContentLoaded', function () {
    // Initialize AOS Animation Library
    AOS.init({
        duration: 800,
        easing: 'ease-out',
        once: true,
        offset: 100
    });

    // Theme Toggle
    initThemeToggle();

    // Navbar Scroll Effect
    initNavbarScroll();

    // Back to Top Button
    initBackToTop();

    // Form Validation
    initFormValidation();

    // Result Lookup
    initResultLookup();

    // Admin Panel
    initAdminPanel();

    // Course Filter
    initCourseFilter();
});

// Theme Toggle
function initThemeToggle() {
    const themeToggle = document.getElementById('themeToggle');
    if (!themeToggle) return;

    const savedTheme = localStorage.getItem('theme') || 'light';
    document.documentElement.setAttribute('data-theme', savedTheme);
    updateThemeIcon(savedTheme);

    themeToggle.addEventListener('click', function () {
        const currentTheme = document.documentElement.getAttribute('data-theme');
        const newTheme = currentTheme === 'dark' ? 'light' : 'dark';

        document.documentElement.setAttribute('data-theme', newTheme);
        localStorage.setItem('theme', newTheme);
        updateThemeIcon(newTheme);
    });
}

function updateThemeIcon(theme) {
    const themeToggle = document.getElementById('themeToggle');
    if (!themeToggle) return;

    const icon = themeToggle.querySelector('i');
    if (theme === 'dark') {
        icon.className = 'bi bi-sun-fill';
    } else {
        icon.className = 'bi bi-moon-fill';
    }
}

// Navbar Scroll Effect
function initNavbarScroll() {
    const navbar = document.getElementById('mainNavbar');
    if (!navbar) return;

    function handleScroll() {
        if (window.scrollY > 50) {
            navbar.classList.add('scrolled');
        } else {
            navbar.classList.remove('scrolled');
        }
    }

    window.addEventListener('scroll', handleScroll);
    handleScroll();
}

// Back to Top Button
function initBackToTop() {
    const backToTop = document.getElementById('backToTop');
    if (!backToTop) return;

    function handleScroll() {
        if (window.scrollY > 500) {
            backToTop.classList.add('visible');
        } else {
            backToTop.classList.remove('visible');
        }
    }

    window.addEventListener('scroll', handleScroll);

    backToTop.addEventListener('click', function () {
        window.scrollTo({
            top: 0,
            behavior: 'smooth'
        });
    });
}

// Form Validation
function initFormValidation() {
    const forms = document.querySelectorAll('.needs-validation');

    forms.forEach(function (form) {
        form.addEventListener('submit', function (event) {
            if (!form.checkValidity()) {
                event.preventDefault();
                event.stopPropagation();
            }
            form.classList.add('was-validated');
        });
    });

    // Payment method toggle
    const paymentMethodSelect = document.getElementById('paymentMethod');
    if (paymentMethodSelect) {
        paymentMethodSelect.addEventListener('change', function () {
            const value = this.value;
            document.querySelectorAll('.payment-details').forEach(el => el.classList.add('d-none'));

            if (value === 'cash') {
                document.getElementById('cashDetails')?.classList.remove('d-none');
            } else if (value === 'dd') {
                document.getElementById('ddDetails')?.classList.remove('d-none');
            } else if (value === 'cheque') {
                document.getElementById('chequeDetails')?.classList.remove('d-none');
            }
        });
    }
}

// Result Lookup
function initResultLookup() {
    const resultForm = document.getElementById('resultForm');
    const resultCard = document.getElementById('resultCard');
    const resultNotFound = document.getElementById('resultNotFound');

    if (!resultForm) return;

    // Mock results data
    const mockResults = {
        'SL2024001': {
            name: 'John Doe',
            rollNumber: 'SL2024001',
            marks: 85,
            classSegregated: 'Advanced (Without Basics)',
            fees: 4275,
            paymentDeadline: 'January 25, 2025'
        },
        'SL2024002': {
            name: 'Jane Smith',
            rollNumber: 'SL2024002',
            marks: 65,
            classSegregated: 'Basics Included',
            fees: 6000,
            paymentDeadline: 'January 25, 2025'
        },
        'SL2024003': {
            name: 'Mike Johnson',
            rollNumber: 'SL2024003',
            marks: 78,
            classSegregated: 'Advanced (Without Basics)',
            fees: 4275,
            paymentDeadline: 'January 25, 2025'
        }
    };

    resultForm.addEventListener('submit', function (event) {
        event.preventDefault();

        const rollNumber = document.getElementById('rollNumber').value.trim().toUpperCase();

        if (resultCard) resultCard.classList.add('d-none');
        if (resultNotFound) resultNotFound.classList.add('d-none');

        if (mockResults[rollNumber]) {
            const result = mockResults[rollNumber];

            document.getElementById('resultName').textContent = result.name;
            document.getElementById('resultRollNumber').textContent = result.rollNumber;
            document.getElementById('resultMarks').textContent = result.marks + '/100';
            document.getElementById('resultClass').textContent = result.classSegregated;
            document.getElementById('resultFees').textContent = '$' + result.fees.toLocaleString();
            document.getElementById('resultDeadline').textContent = result.paymentDeadline;

            if (resultCard) {
                resultCard.classList.remove('d-none');
                resultCard.scrollIntoView({ behavior: 'smooth', block: 'center' });
            }
        } else {
            if (resultNotFound) resultNotFound.classList.remove('d-none');
        }
    });
}

// Admin Panel
function initAdminPanel() {
    const sidebarToggle = document.getElementById('sidebarToggle');
    const adminSidebar = document.getElementById('adminSidebar');
    const adminMain = document.getElementById('adminMain');

    if (sidebarToggle && adminSidebar) {
        sidebarToggle.addEventListener('click', function () {
            adminSidebar.classList.toggle('show');
        });
    }

    // Admin Login
    const adminLoginForm = document.getElementById('adminLoginForm');
    if (adminLoginForm) {
        adminLoginForm.addEventListener('submit', function (event) {
            event.preventDefault();

            const username = document.getElementById('adminUsername').value;
            const password = document.getElementById('adminPassword').value;

            // Mock authentication
            if (username === 'admin' && password === 'admin123') {
                localStorage.setItem('adminLoggedIn', 'true');
                window.location.href = 'admin-dashboard.html';
            } else {
                const errorDiv = document.getElementById('loginError');
                if (errorDiv) {
                    errorDiv.textContent = 'Invalid username or password';
                    errorDiv.classList.remove('d-none');
                }
            }
        });
    }

    // Check admin authentication
    const isAdminPage = window.location.pathname.includes('admin-dashboard');
    if (isAdminPage) {
        const isLoggedIn = localStorage.getItem('adminLoggedIn');
        if (!isLoggedIn) {
            window.location.href = 'admin.html';
        }
    }

    // Admin logout
    const logoutBtn = document.getElementById('adminLogout');
    if (logoutBtn) {
        logoutBtn.addEventListener('click', function (event) {
            event.preventDefault();
            localStorage.removeItem('adminLoggedIn');
            window.location.href = 'admin.html';
        });
    }

    // Admin form submissions (mock)
    initAdminForms();
}

function initAdminForms() {
    // Course Form
    const courseForm = document.getElementById('courseForm');
    if (courseForm) {
        courseForm.addEventListener('submit', function (event) {
            event.preventDefault();
            showToast('Course saved successfully!', 'success');
            courseForm.reset();
        });
    }

    // Exam Form
    const examForm = document.getElementById('examForm');
    if (examForm) {
        examForm.addEventListener('submit', function (event) {
            event.preventDefault();
            showToast('Exam details saved successfully!', 'success');
            examForm.reset();
        });
    }

    // Result Form
    const adminResultForm = document.getElementById('adminResultForm');
    if (adminResultForm) {
        adminResultForm.addEventListener('submit', function (event) {
            event.preventDefault();
            showToast('Result added successfully!', 'success');
            adminResultForm.reset();
        });
    }

    // FAQ Form
    const faqForm = document.getElementById('faqForm');
    if (faqForm) {
        faqForm.addEventListener('submit', function (event) {
            event.preventDefault();
            showToast('FAQ saved successfully!', 'success');
            faqForm.reset();
        });
    }

    // Center Form
    const centerForm = document.getElementById('centerForm');
    if (centerForm) {
        centerForm.addEventListener('submit', function (event) {
            event.preventDefault();
            showToast('Center information saved successfully!', 'success');
            centerForm.reset();
        });
    }
}

// Course Filter
function initCourseFilter() {
    const searchInput = document.getElementById('courseSearch');
    const categoryFilter = document.getElementById('categoryFilter');
    const courseCards = document.querySelectorAll('.course-card-item');

    if (!searchInput || !courseCards.length) return;

    function filterCourses() {
        const searchTerm = searchInput.value.toLowerCase();
        const selectedCategory = categoryFilter ? categoryFilter.value : 'all';

        courseCards.forEach(function (card) {
            const title = card.querySelector('.course-title')?.textContent.toLowerCase() || '';
            const description = card.querySelector('.course-description')?.textContent.toLowerCase() || '';
            const category = card.dataset.category || '';

            const matchesSearch = title.includes(searchTerm) || description.includes(searchTerm);
            const matchesCategory = selectedCategory === 'all' || category === selectedCategory;

            if (matchesSearch && matchesCategory) {
                card.style.display = '';
            } else {
                card.style.display = 'none';
            }
        });

        // Show/hide no results message
        const visibleCards = document.querySelectorAll('.course-card-item:not([style*="display: none"])');
        const noResults = document.getElementById('noResults');
        if (noResults) {
            noResults.style.display = visibleCards.length === 0 ? 'block' : 'none';
        }
    }

    if (searchInput) searchInput.addEventListener('input', filterCourses);
    if (categoryFilter) categoryFilter.addEventListener('change', filterCourses);
}

// Toast Notification
function showToast(message, type = 'success') {
    const toastContainer = document.getElementById('toastContainer');
    if (!toastContainer) {
        const container = document.createElement('div');
        container.id = 'toastContainer';
        container.className = 'toast-container position-fixed bottom-0 end-0 p-3';
        container.style.zIndex = '1100';
        document.body.appendChild(container);
    }

    const toastId = 'toast-' + Date.now();
    const toastHTML = `
        <div id="${toastId}" class="toast align-items-center text-bg-${type === 'success' ? 'success' : 'danger'} border-0" role="alert">
            <div class="d-flex">
                <div class="toast-body">
                    <i class="bi bi-${type === 'success' ? 'check-circle' : 'exclamation-circle'} me-2"></i>
                    ${message}
                </div>
                <button type="button" class="btn-close btn-close-white me-2 m-auto" data-bs-dismiss="toast"></button>
            </div>
        </div>
    `;

    document.getElementById('toastContainer').insertAdjacentHTML('beforeend', toastHTML);

    const toastElement = document.getElementById(toastId);
    const toast = new bootstrap.Toast(toastElement, { delay: 3000 });
    toast.show();

    toastElement.addEventListener('hidden.bs.toast', function () {
        toastElement.remove();
    });
}

// Exam Application Form
const examApplicationForm = document.getElementById('examApplicationForm');
if (examApplicationForm) {
    examApplicationForm.addEventListener('submit', function (event) {
        event.preventDefault();

        if (!examApplicationForm.checkValidity()) {
            event.stopPropagation();
            examApplicationForm.classList.add('was-validated');
            return;
        }

        // Generate roll number
        const rollNumber = 'SL' + new Date().getFullYear() + String(Math.floor(Math.random() * 9000) + 1000);

        // Show success modal
        const successModal = document.getElementById('successModal');
        if (successModal) {
            document.getElementById('generatedRollNumber').textContent = rollNumber;
            const modal = new bootstrap.Modal(successModal);
            modal.show();
        }

        examApplicationForm.reset();
        examApplicationForm.classList.remove('was-validated');
    });
}

