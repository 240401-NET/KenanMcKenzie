//base url and specifying headers
import axios from "axios";

export const apiClient = axios.create({
  baseUrl: "http://localhost:5232",
});
