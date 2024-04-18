import axios from "axios";
//crud calls

const API_URL = "http://localhost:5232";

export const loginUser = (email, password) => {
  return axios.post(
    `${API_URL}/user/login`,
    { email, password },
    {
      withCredentials: true,
      headers: {
        "Content-Type": "application/json",
        Accept: "application/json",
      },
    }
  );
};

export const signUp = (name, email, password) => {
  return axios.post(
    `${API_URL}/user/register`,
    {
      name,
      email,
      password,
    },
    {
      withCredentials: true,
      headers: {
        "Content-Type": "application/json",
        Accept: "application/json",
      },
    }
  );
};
