document.addEventListener('DOMContentLoaded', function () {
  // =========================
  // Theme (Dark mode toggle)
  // =========================
  var root = document.documentElement;
  var storageKey = 'hotelappui-theme';
  var themeToggle = document.getElementById('themeToggle');

  function getPreferredTheme() {
    try {
      var saved = localStorage.getItem(storageKey);
      if (saved === 'dark' || saved === 'light') return saved;
    } catch (_) { /* ignore */ }
    return (window.matchMedia && window.matchMedia('(prefers-color-scheme: dark)').matches) ? 'dark' : 'light';
  }

  function setTheme(next) {
    if (next === 'dark') root.setAttribute('data-theme', 'dark');
    else root.removeAttribute('data-theme');

    try { localStorage.setItem(storageKey, next); } catch (_) { /* ignore */ }

    if (themeToggle) {
      var icon = themeToggle.querySelector('i');
      var label = themeToggle.querySelector('span');
      var isDark = next === 'dark';
      if (icon) icon.className = isDark ? 'fas fa-sun me-2' : 'fas fa-moon me-2';
      if (label) label.textContent = isDark ? 'Switch to light mode' : 'Switch to dark mode';
    }
  }

  setTheme(getPreferredTheme());

  if (themeToggle) {
    themeToggle.addEventListener('click', function () {
      var isDark = root.getAttribute('data-theme') === 'dark';
      setTheme(isDark ? 'light' : 'dark');
    });
  }

  // =========================
  // Toast auto-dismiss
  // =========================
  document.querySelectorAll('.app-toast[data-auto-dismiss="true"]').forEach(function (toast) {
    setTimeout(function () {
      toast.style.animation = 'toastSlideIn 0.25s ease-in reverse';
      setTimeout(function () { toast.remove(); }, 250);
    }, 4500);
  });
});
