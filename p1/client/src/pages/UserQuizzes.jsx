import Header from "../components/Header";
import QuizzesTable from "../components/QuizzesTable";

const UserQuizzes = () => {
  return (
    <div className="bg-neutral-content max-w-full h-screen">
      <Header title="User Quizzes" />
      <div className="py-16 mx-24 border border-zinc-200 bg-zinc-500 rounded-lg shadow-xl">
        <QuizzesTable />
      </div>
    </div>
  );
};

export default UserQuizzes;
