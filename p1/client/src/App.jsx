import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import NavBar from "./components/NavBar";
import Landing from "./pages/Landing";
import UserQuizzes from "./pages/UserQuizzes";
import CreateQuiz from "./pages/CreateQuiz";
import SignUpForm from "./components/SignUpForm";
import SignInForm from "./components/SignInForm";

function App() {
  return (
    <Router>
      <NavBar />
      <Routes>
        <Route path="/" element={<Landing />} />
        <Route path="/user" element={<UserQuizzes />} />
        <Route path="/signin" element={<SignInForm />} />
        <Route path="/signup" element={<SignUpForm />} />
        <Route path="/create" element={<CreateQuiz />} />
      </Routes>
    </Router>
  );
}

export default App;
