import clsx from "clsx";
import { css, keyframes } from "@emotion/react";

const rippleAnimation = keyframes`
  0% {
    transform: scale(1);
    opacity: 1;
  }
  50% {
    transform: scale(1.5);
    opacity: 0.5;
  }
  100% {
    transform: scale(1);
    opacity: 0;
  }
`;

const style = css`
  background-color: red;
  &:before {
    content: "";
    position: absolute;
    top: 0;
    right: 0;
    width: 8px;
    height: 8px;
    border-radius: calc(infinity * 1px);
    background-color: red;
    z-index: 1;
    animation: ${rippleAnimation} 1s infinite;
  }
`;

const NotificationDot = () => {
  return (
    <div
      className={clsx(
        "absolute top-0 right-0 z-2",
        "size-[8px] rounded-full",
        "translate-x-[-5px] translate-y-[5px]"
      )}
      css={style}
    ></div>
  );
};

export default NotificationDot;
