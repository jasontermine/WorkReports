import axios from "axios";

export const base = axios.create({
  baseURL: "http://localhost:5104/api",
  headers: {
    "Content-Type": "application/json",
  },
});
