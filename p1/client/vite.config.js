import { defineConfig } from "vite";
import react from "@vitejs/plugin-react-swc";
import mkcert from "vite-plugin-mkcert";
// https://vitejs.dev/config/
export default defineConfig({
  base: "/KenanMcKenzie/p1/client/",
  plugins: [react(), mkcert()],
  server: {
    proxy: {
      "^/api": "http://localhost:5232",
    },
    port: 5173,
  },
});
