import axios from "axios";
import { apiClient } from "./axios";
// //crud calls

// import { apiClient } from "./axios";

// export const signUp = async (Name, UserName, Email, PasswordHash) => {
//   console.log(`${API_URL}/user/register`);
//   return axios.post(
//     `${API_URL}/user/register`,
//     {
//       Name,
//       UserName,
//       Email,
//       PasswordHash,
//     },
//     {
//       withCredentials: true,
//       headers: {
//         "Content-Type": "application/json",
//         Accept: "application/json",
//       },
//     }
//   );
// };

export const logOut = () => {
  return axios.get(`${apiClient}/user/logout`, {
    withCredentials: true,
  });
};
