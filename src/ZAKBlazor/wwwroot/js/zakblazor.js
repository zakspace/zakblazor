/**
 * ZAKBlazor Minimal JavaScript Interop
 * Used solely for browser capabilities not directly accessible via Blazor/CSS.
 */
window.zakBlazor = {
  setStorageItem: function (key, value) {
    try {
      localStorage.setItem(key, value);
    } catch (e) {
      console.warn("zakBlazor: LocalStorage write failed", e);
    }
  },

  getStorageItem: function (key) {
    try {
      return localStorage.getItem(key);
    } catch (e) {
      return null;
    }
  },

  setTheme: function (theme) {
    try {
      document.documentElement.setAttribute("data-theme", theme);
      if (theme === "dark") {
        document.documentElement.classList.add("zak-theme-dark");
        document.documentElement.classList.remove("zak-theme-light");
      } else {
        document.documentElement.classList.add("zak-theme-light");
        document.documentElement.classList.remove("zak-theme-dark");
      }
    } catch (e) {
      console.warn("zakBlazor: setTheme failed", e);
    }
  },

  copyToClipboard: async function (text) {
    try {
      if (navigator.clipboard && window.isSecureContext) {
        await navigator.clipboard.writeText(text);
        return true;
      } else {
        const textArea = document.createElement("textarea");
        textArea.value = text;
        textArea.style.position = "fixed";
        textArea.style.left = "-999999px";
        document.body.appendChild(textArea);
        textArea.focus();
        textArea.select();
        const successful = document.execCommand("copy");
        textArea.remove();
        return successful;
      }
    } catch (err) {
      console.error("zakBlazor: Failed to copy to clipboard", err);
      return false;
    }
  }
};
