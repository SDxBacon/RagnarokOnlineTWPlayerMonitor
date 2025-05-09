import { useState } from "react";
import { Loader2 } from "lucide-react";
import { Button } from "@/components/ui/button";

interface StartCaptureButtonProps
  extends React.ButtonHTMLAttributes<HTMLButtonElement> {
  isLoading?: boolean;
}

function StartCaptureButton(props: StartCaptureButtonProps) {
  const { isLoading = false, ...rest } = props;

  return (
    <Button disabled={isLoading} {...rest}>
      {isLoading ? (
        <>
          <Loader2 className="animate-spin" />
          Please wait
        </>
      ) : (
        "Start"
      )}
    </Button>
  );
}

export default StartCaptureButton;
