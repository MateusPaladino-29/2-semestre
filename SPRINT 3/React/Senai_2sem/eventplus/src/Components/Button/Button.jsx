import "./Button.css";

const Button = ({ tipo, textoBotao }) => {
  return (
    <>
      <button type={tipo}>{textoBotao}</button>
    </>
  );
};

export default Button;
