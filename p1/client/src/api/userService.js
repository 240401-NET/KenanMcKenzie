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

export const signUp = async (Name, UserName, Email, PasswordHash) => {
  console.log(`${API_URL}/user/register`);
  return axios.post(
    `${API_URL}/user/register`,
    {
      Name,
      UserName,
      Email,
      PasswordHash,
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

export const logOut = () => {
  return axios.get(`${API_URL}/user/logout`, {
    withCredentials: true,
  });
};
