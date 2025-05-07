import { config } from "../../wailsjs/go/models";
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "@/components/ui/select";

interface ServerSelectProps {
  options: config.LoginServer[];
}

const ServerSelect = (props: ServerSelectProps) => {
  const { options } = props;
  return (
    <Select>
      <SelectTrigger className="w-[180px]">
        <SelectValue placeholder="Please select a server" />
      </SelectTrigger>
      <SelectContent>
        {options.map((option) => (
          <SelectItem key={option.Name} value={option.Name}>
            {option.Name}
          </SelectItem>
        ))}
      </SelectContent>
    </Select>
  );
};

export default ServerSelect;
